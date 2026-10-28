# Course Registration and FIFO Waitlist

## Overview
A C# console application that manages enrollment,
dropping, and FIFO waitlist promotion for one course.

## Features
- Enroll eligible learners
- Enforce course capacity
- Maintain a FIFO waitlist
- Prevent duplicate registrations
- Promote the earliest waitlisted learner
- Handle invalid requests and repeated drops
- Protect shared state using locking

## Technology
- C#
- .NET 5
- MSTest
- In-memory collections

## Run Application
```bash
dotnet run --project CourseRegistration/CourseRegistration.csproj
```

## Run Tests
```bash
dotnet test CourseRegistration.Tests/CourseRegistration.Tests.csproj
```

## Assumptions
- A learner must satisfy prerequisites before registration.
- Ineligible learners cannot join the waitlist.
- Eligibility is checked when enrolling.
- The application manages one course.
- Data is stored in memory and is not persistent.

## Limitations
- Data is lost when the application restarts.
- No frontend or external database.
- No authentication or external integrations.
- .NET 5 is out of support; upgrading is recommended.
