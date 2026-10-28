using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseRegistration
{
public enum RegistrationResult
{
Enrolled,
Waitlisted,
AlreadyEnrolled,
AlreadyWaitlisted,
NotEligible,
Dropped,
RemovedFromWaitlist,
NotRegistered,
InvalidRequest
}

public class CourseService
{
private readonly int capacity;
private readonly HashSet<string> enrolled =
new HashSet<string>();

private readonly Queue<string> waitlist =
new Queue<string>();

private readonly object sync = new object();

public CourseService(int capacity)
{
if (capacity <= 0)
throw new ArgumentOutOfRangeException(
nameof(capacity));

this.capacity = capacity;
}

public RegistrationResult Enroll(
string learnerId, bool eligible)
{
lock (sync)
{
if (string.IsNullOrWhiteSpace(learnerId))
return RegistrationResult.InvalidRequest;

learnerId = learnerId.Trim();

if (enrolled.Contains(learnerId))
return RegistrationResult.AlreadyEnrolled;

if (waitlist.Contains(learnerId))
return RegistrationResult.AlreadyWaitlisted;

if (!eligible)
return RegistrationResult.NotEligible;

if (enrolled.Count < capacity)
{
enrolled.Add(learnerId);
return RegistrationResult.Enrolled;
}

waitlist.Enqueue(learnerId);
return RegistrationResult.Waitlisted;
}
}

public RegistrationResult Drop(string learnerId)
{
lock (sync)
{
if (string.IsNullOrWhiteSpace(learnerId))
return RegistrationResult.InvalidRequest;

learnerId = learnerId.Trim();

if (enrolled.Remove(learnerId))
{
PromoteNext();
return RegistrationResult.Dropped;
}

if (waitlist.Contains(learnerId))
{
var remaining = waitlist
.Where(x => x != learnerId).ToArray();

waitlist.Clear();

foreach (var id in remaining)
waitlist.Enqueue(id);

return RegistrationResult.RemovedFromWaitlist;
}

return RegistrationResult.NotRegistered;
}
}

private void PromoteNext()
{
if (enrolled.Count < capacity &&
waitlist.Count > 0)
{
string next = waitlist.Dequeue();
enrolled.Add(next);
}
}

public bool IsEnrolled(string learnerId)
{
lock (sync)
{
return learnerId != null &&
enrolled.Contains(learnerId.Trim());
}
}

public string[] GetWaitlist()
{
lock (sync)
{
return waitlist.ToArray();
}
}

public int EnrolledCount
{
get
{
lock (sync)
return enrolled.Count;
}
}

public int AvailableSeats
{
get
{
lock (sync)
return capacity - enrolled.Count;
}
}
}
}
