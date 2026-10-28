AI-Assisted Engineering Usage Record
1. Purpose
AI assistance was used during the development of the Course Registration and FIFO Waitlist assessment to support implementation, debugging, test preparation, and documentation.

All generated suggestions require independent review and verification before final submission.

2. AI Tool Used
Tool: ChatGPT (OpenAI)
Language: C#
Project: Course Registration and FIFO Waitlist
Development Environment: Visual Studio Code
Framework: .NET 5
3. AI Interaction Record
Interaction 1: Initial Implementation
Prompt summary:

“Help implement a C# course registration system supporting enrollment, prerequisite validation, FIFO waitlisting, and dropping.”

AI contribution:

Suggested an in-memory implementation using HashSet, Queue, and C# synchronization.

Decision: Accepted as an initial implementation and subsequently revised.

Verification: Executed the console application and inspected enrollment and drop results.

Interaction 2: Refactoring and Error Resolution
Prompt summary:

“Help improve the course registration implementation and resolve compilation and build errors.”

AI contribution:

Suggested separating the service from Program.cs and provided guidance for resolving missing braces, missing method references, and a locked executable.

Decision: Edited and applied during development.

Verification: Rebuilt and executed the application successfully.

Interaction 3: Automated Unit Testing
Prompt summary:

“Provide MSTest unit tests for course enrollment, FIFO waitlist promotion, invalid requests, duplicate registrations, and dropping.”

AI contribution:

Suggested automated test cases covering the principal business rules.

Decision: Accepted for initial test coverage.

Verification: Executed dotnet test and observed 12 passing tests.

Interaction 4: Technical Documentation
Prompt summary:

“Prepare a technical design specification describing the course service, data structures, business rules, FIFO promotion, concurrency, and limitations.”

AI contribution:

Generated an initial design specification.

Decision: Used as a documentation draft, subject to review against the implementation.

Verification: Compare the design document against the final source code and test results before submission.

4. Independent Verification
The following activities were performed during development:

Built the console application.
Executed the application and inspected its output.
Verified basic enrollment and waitlist behavior.
Executed 12 automated MSTest cases.
Confirmed that the test run reported 12 passing tests.
5. Final Verification

The following verification activities were completed:

Executed 12 automated MSTest cases.
Verified concurrent enrollment capacity.
Verified FIFO waitlist promotion order.
Confirmed all 12 tests passed with 0 failures.

6. Limitations of AI Assistance
AI-generated code and documentation may contain mistakes or incomplete assumptions. Successful compilation alone does not establish correctness.

The final implementation must be reviewed against the assessment acceptance criteria, with particular attention to eligibility rules, duplicate requests, capacity invariants, and concurrent operations.

7. Conclusion
AI was used as an engineering assistant for implementation suggestions, debugging, test generation, and documentation.

The resulting code was executed and tested during development. Remaining verification activities should be completed and recorded before submission.