# Course Registration and FIFO Waitlist

## Project Overview

This project implements a Course Registration and FIFO Waitlist Management System using C# and .NET 5.

The application supports enrollment, dropping, prerequisite eligibility validation, and automatic waitlist promotion for a single course.

## Features

- Enroll eligible learners when seats are available.
- Add eligible learners to a FIFO waitlist when the course is full.
- Prevent duplicate enrollment and waitlist entries.
- Automatically promote the earliest waitlisted learner when a seat becomes available.
- Reject learners who do not satisfy prerequisites.
- Handle invalid requests and repeated drops.
- Support thread-safe operations using locking.

## Technologies Used

- C#
- .NET 5
- MSTest
- Git and GitHub

## Project Structure

- `CourseRegistration/` - Main application and documentation.
- `CourseRegistration.Tests/` - Automated unit tests.

## Prerequisites

Install the .NET 5 SDK to run the project.

Note: .NET 5 is out of support and is used here for the assessment environment.

## How to Run the Application

Open a terminal in the repository root and execute:

dotnet run --project CourseRegistration/CourseRegistration.csproj

## How to Run Automated Tests

Execute:

dotnet test CourseRegistration.Tests/CourseRegistration.Tests.csproj

## Test Coverage

Automated tests cover:

- Successful enrollment
- Full course capacity
- Duplicate enrollment
- Duplicate waitlist requests
- FIFO waitlist promotion
- Prerequisite failure
- Invalid enrollment requests
- Repeated drops
- Waitlist cancellation
- Capacity enforcement
- Concurrent enrollment requests

## Design Decisions

- A HashSet stores enrolled learners.
- A Queue maintains FIFO waitlist ordering.
- A lock protects shared state during concurrent operations.
- Course capacity must always be respected.
- Learners cannot be enrolled and waitlisted simultaneously.

## Waitlist Eligibility Policy

Prerequisite eligibility is checked when enrollment is requested.

Ineligible learners are rejected and cannot join the waitlist.

Eligibility is assumed to remain unchanged while learners are waiting.

Therefore, an ineligible learner cannot reach the front of the waitlist under the current policy.

Dynamic prerequisite changes are outside the current scope.

## Documentation

- [Design Specification](CourseRegistration/DESIGN.md)
- [AI Usage Record](CourseRegistration/AI_USAGE.md)
- [Limitations](CourseRegistration/LIMITATIONS.md)

## Limitations

- Supports one course offering.
- Uses in-memory storage.
- Data is not persisted after application termination.
- Does not include a web interface or database.
- Dynamic eligibility changes are not supported.

## AI Assistance

AI was used to assist with implementation planning, code suggestions, test development, and documentation.

AI-generated suggestions were reviewed and verified through local builds, application execution, and automated tests.

See AI_USAGE.md for further details.
