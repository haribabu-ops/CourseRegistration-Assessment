using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseRegistration;

namespace CourseRegistration.Tests
{
[TestClass]
public class CourseServiceTests
{
[TestMethod]
public void AvailableSeat_EnrollsLearner()
{
var course = new CourseService(2);

var result = course.Enroll("A", true);

Assert.AreEqual(
RegistrationResult.Enrolled, result);
Assert.AreEqual(1, course.EnrolledCount);
}

[TestMethod]
public void FullCourse_AddsToWaitlist()
{
var course = new CourseService(1);

course.Enroll("A", true);
var result = course.Enroll("B", true);

Assert.AreEqual(
RegistrationResult.Waitlisted, result);
Assert.AreEqual(1, course.GetWaitlist().Length);
}

[TestMethod]
public void DuplicateEnrollment_IsRejected()
{
var course = new CourseService(1);

course.Enroll("A", true);

Assert.AreEqual(
RegistrationResult.AlreadyEnrolled,
course.Enroll("A", true));
}

[TestMethod]
public void DuplicateWaitlist_IsRejected()
{
var course = new CourseService(1);

course.Enroll("A", true);
course.Enroll("B", true);

Assert.AreEqual(
RegistrationResult.AlreadyWaitlisted,
course.Enroll("B", true));
}

[TestMethod]
public void Drop_PromotesFirstWaitlistedLearner()
{
var course = new CourseService(1);

course.Enroll("A", true);
course.Enroll("B", true);
course.Enroll("C", true);

course.Drop("A");

Assert.IsTrue(course.IsEnrolled("B"));
Assert.IsFalse(course.IsEnrolled("C"));
}

[TestMethod]
public void IneligibleLearner_IsRejected()
{
var course = new CourseService(1);

Assert.AreEqual(
RegistrationResult.NotEligible,
course.Enroll("A", false));
}

[TestMethod]
public void RepeatedDrop_ReturnsNotRegistered()
{
var course = new CourseService(1);

course.Enroll("A", true);
course.Drop("A");

Assert.AreEqual(
RegistrationResult.NotRegistered,
course.Drop("A"));
}

[TestMethod]
public void InvalidRequest_IsRejected()
{
var course = new CourseService(1);

Assert.AreEqual(
RegistrationResult.InvalidRequest,
course.Enroll("", true));

Assert.AreEqual(
RegistrationResult.InvalidRequest,
course.Drop(null));
}

[TestMethod]
public void WaitlistedLearner_CanCancel()
{
var course = new CourseService(1);

course.Enroll("A", true);
course.Enroll("B", true);

Assert.AreEqual(
RegistrationResult.RemovedFromWaitlist,
course.Drop("B"));

Assert.AreEqual(0, course.GetWaitlist().Length);
}

[TestMethod]
public void Capacity_NeverExceeded()
{
var course = new CourseService(2);

course.Enroll("A", true);
course.Enroll("B", true);
course.Enroll("C", true);

Assert.AreEqual(2, course.EnrolledCount);
Assert.AreEqual(0, course.AvailableSeats);
}
[TestMethod]
public void ConcurrentEnrollment_NeverExceedsCapacity()
{
var course = new CourseService(5);

Parallel.For(0, 100, i =>
{
course.Enroll("Student" + i, true);
});

Assert.AreEqual(5, course.EnrolledCount);
Assert.AreEqual(95, course.GetWaitlist().Length);
Assert.AreEqual(0, course.AvailableSeats);
}
[TestMethod]
public void MultipleDrops_PromoteLearnersInFIFOOrder()
{
var course = new CourseService(1);

course.Enroll("A", true);
course.Enroll("B", true);
course.Enroll("C", true);
course.Enroll("D", true);

course.Drop("A");

Assert.IsTrue(course.IsEnrolled("B"));
CollectionAssert.AreEqual(
new[] { "C", "D" },
course.GetWaitlist());

course.Drop("B");

Assert.IsTrue(course.IsEnrolled("C"));
CollectionAssert.AreEqual(
new[] { "D" },
course.GetWaitlist());
}

}
}
