Course Registration & FIFO Waitlist — Design Specification
1. Objective
Implement a reliable, in-memory course registration service that supports enrollment, dropping, prerequisite validation, and FIFO waitlist promotion for a single course offering.

2. Technology Stack
Language: C#
Framework: .NET 5
Application: Console Application
Testing: MSTest
Storage: In-memory collections
Concurrency: C# lock synchronization
3. Architecture
The application consists of two main components:

Program.cs

Demonstrates enrollment and drop operations.
Displays registration results.
CourseService.cs

Implements the registration business logic.
Maintains enrolled learners and the waitlist.
Enforces capacity and duplicate-prevention rules.
Promotes waitlisted learners when seats become available.
CourseRegistration.Tests

Contains automated tests for the service.
4. Data Structures
HashSet of learner IDs

Stores enrolled learners and prevents duplicate enrollments.

Queue of learner IDs

Maintains FIFO ordering for waitlisted learners.

Synchronization object

Protects operations that read or modify shared registration state.

5. Enrollment Algorithm
Validate the learner ID.
Check whether the learner is already enrolled.
Check whether the learner is already waitlisted.
Verify prerequisite eligibility.
If capacity is available, enroll the learner.
Otherwise, add the learner to the waitlist.
Return a clear registration result.
6. Drop and Promotion Algorithm
Validate the learner ID.
If enrolled, remove the learner.
If a seat becomes available, dequeue the earliest waitlisted learner and promote them.
If the learner is waitlisted, remove their entry without affecting enrollment.
If the learner is not registered, return NotRegistered.
7. Business Rules and Assumptions
Only one course offering is supported.
Course capacity must be greater than zero.
Learners must satisfy prerequisites before joining enrollment or the waitlist.
Ineligible learners are rejected rather than retained in the waitlist.
Eligibility is supplied during enrollment and is assumed not to change while waiting.
A learner cannot be both enrolled and waitlisted.
Repeated enrollment requests do not create duplicate records.
Waitlisted learners can cancel their registration.
8. Capacity and Registration Invariants
The service maintains these invariants:

Enrolled count never exceeds course capacity.
Available seats never become negative.
Each learner appears at most once in the registration state.
Waitlist promotion follows FIFO order.
Invalid requests do not change registration state.
9. Concurrency Approach
The service uses a private synchronization object and C# lock statements to protect registration operations.

This prevents simultaneous enrollment requests from exceeding capacity and protects waitlist updates from concurrent modifications.

The implementation is intended for a single application process.

10. Testing Strategy
Automated MSTest cases cover:

Enrollment with available capacity
Enrollment when the course is full
Duplicate enrollment
Duplicate waitlist requests
FIFO promotion
Prerequisite failure
Repeated drops
Invalid requests
Waitlist cancellation
Capacity enforcement
Additional concurrency testing is recommended before final submission.

11. Tradeoffs
An in-memory implementation was selected because the assessment permits a small service or command-line prototype without a database.

This keeps the implementation focused on correctness and testability rather than infrastructure.

The tradeoff is that registration state is not durable across application restarts.

12. Limitations
No database persistence
No frontend
No authentication
No external prerequisite verification
No multi-course registration
No distributed concurrency control
Eligibility changes after waitlisting are not supported
.NET 5 is out of support and should be upgraded for maintained environments
13. Future Improvements
Potential improvements outside the current scope include persistent storage, structured logging, API endpoints, and support for multiple course offerings.