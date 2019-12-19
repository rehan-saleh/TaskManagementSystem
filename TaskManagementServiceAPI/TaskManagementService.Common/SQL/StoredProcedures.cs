namespace TaskManagementService.Common.SQL
{
    public static class StoredProcedures
    {
        public readonly static string sp_GetAllTasks =
            @"CREATE PROCEDURE sp_GetAllTasks
                AS BEGIN SELECT 
                T.AllTaskId, T.TaskCode, 
                T.CreatedDate, T.TaskSubject, T.TaskBody, 
                T.DueDate, T.isActive, T.isReplyed, T.isClosed,
                T.TaskTypeId, TT.TaskTypeName, T.LevelId, 
                L.LevelName, T.PriorityId, P.PriorityName,
                T.CreatedByEmployeeId,
                CBE.EmployeeName AS CreatedByEmployeeName, 
                CBE.EmployeeCode AS CreatedByEmployeeCode,
                CBED.DepartmentName AS CreatedByEmployeeDepartmentName,
                T.AssignedToEmployeeId,
                ATE.EmployeeName AS AssignedToEmployeeName, 
                ATE.EmployeeCode AS AssignedToEmployeeCode, 
                ATED.DepartmentName AS AssignedToEmployeeDepartmentName, 
                T.AssignedToDepartmentId,
                ATD.DepartmentName AS AssignedToDepartmentName

                FROM tblAllTasks T
                LEFT OUTER JOIN tblTaskTypes TT ON T.TaskTypeId = TT.TaskTypeName
                LEFT OUTER JOIN tblLevels L ON T.LevelId = L.LevelId
                LEFT OUTER JOIN tblPriorities P ON T.PriorityId = P.PriorityId
                LEFT OUTER JOIN tblEmployees CBE ON T.CreatedByEmployeeId = CBE.EmployeeId
                LEFT OUTER JOIN tblEmployees ATE ON T.AssignedToEmployeeId = ATE.EmployeeId
                LEFT OUTER JOIN tblDepartments CBED ON CBE.DepartmentId = CBED.DepartmentId
                LEFT OUTER JOIN tblDepartments ATED ON ATE.DepartmentId = ATED.DepartmentId
                LEFT OUTER JOIN tblDepartments ATD ON T.AssignedToDepartmentId = ATD.DepartmentId
                END";


        public readonly static string sp_GetAllEmployeesInRoles =
            @"CREATE PROCEDURE sp_GetAllEmployeesInRoles
                AS BEGIN 
                    SELECT 
	                e.EmployeeId, 
	                e.EmployeeName, 
	                u.Id AS UserId, 
	                u.UserName 
	                FROM
	                tblEmployeesInRoles er 
	                INNER JOIN tblEmployees e ON er.EmployeeId = e.EmployeeId
	                INNER JOIN AspNetUsers u ON er.UserId = u.Id 
                END";
    }
}
