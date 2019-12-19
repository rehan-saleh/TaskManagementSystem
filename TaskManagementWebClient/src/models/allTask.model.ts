export class AllTaskViewModel {
    public AllTaskId: number;
    public TaskCode: string;
    public CreatedBy: string;
    public AssignedToCode: string;
    public TaskSubject: string;
    public TaskBody: string;
    public CreatedDate: Date;
    public DueDate: Date;
    public isActive: boolean;
    public isReplyed: boolean
    public isClosed: boolean;
    public TaskTypeId: number;
    public TaskTypeName: string;
    public PriorityId: number;
    public PriorityName: string;
    public LevelId: number;
    public LevelName: string;
    public EmployeeId: number;
    public EmployeeName: string;
    public EmployeeCode: string;
    public BranchName: string;
    public DepartmentId: number;
    public DepartmentName: string;
    public DesignationName: string;
    public TaskDetailId: number;
    public Comment: string;
    public CommentDateTime: Date;
    public isCommentReplyed: string;
    public CommentEmployeeName: string;
}

export class AllTask {
    public allTaskId: number;
    public taskCode: string;
    public createdBy: string;
    public assignedToCode: string;
    public taskSubject: string;
    public taskBody: string;
    public createdDate: Date;
    public dueDate: Date;
    public IsActive: boolean;
    public IsReplyed: boolean
    public IsClosed: boolean;
    public taskTypeId: number;
    public taskTypeName: string;
    public levelId: number;
    public levelName: string;
    public priorityId: number;
    public priorityName: string;
    public employeeId: number;
    public employeeName: string;
    public employeeCode: string;
    public branchName: string;
    public departmentId: number;
    public departmentName: string;
    public designationName: string;
    public taskDetailId: number;
    public comment: string;
    public commentDateTime: Date;
    public IsCommentReplyed: string;
    public commentEmployeeName: string;
}