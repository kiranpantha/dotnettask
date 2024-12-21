
## Candidate Add/Update

### Database Used:
**SQLite** was chosen as the database for this implementation. The connection string is configured for easy integration and local testing.

### Unique Identifier
The **Email** field is used as the unique identifier for candidate profiles. This ensures that any update or creation operation is always based on the candidate's email address.



### Ways for Improvement
1. **Database Optimization**:
   - Using other faster and powerful alternate other than SQLite like MSSQL

2. **Code Quality**:
   - Introduce comments for critical sections of code for better maintainability.

3. **Error Handling**:
   - Include detailed error messages for scenarios beyond validation.

4. **Testing**:
   - Extend unit tests to cover edge cases, such as invalid LinkedIn or GitHub URLs.
   - Add integration tests for validating API functionality.

5. **Documentation**:
   - Provided API documentation (e.g., Swagger) to make the API easier to use.

---

## Assumptions
1. **SQLite** is used as the database, assuming this suffices for initial use cases.
2. The application is expected to operate locally, and scaling will be considered in future iterations.
3. Time intervals for calls are treated as plain strings for this implementation.
4. Dot Net Core WebApp is used.
---

## Total Time Spent
**2 hours** (Evidence Backed by Git Commits)

This includes:
- Setting up the project structure.
- Creating the SQLite database using **DB Browser for SQLite** .
- Implementing the API endpoint for creating and updating candidates.
- Writing and refining the repository logic.
- Screenshots are Attached to [https://github.com/kiranpantha/dotnettask/tree/main/upload]
