import { Component, OnInit } from '@angular/core';
import { TasksService } from './tasks.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AllTaskViewModel, AllTask } from 'src/models/allTask.model';
import { TaskTypeViewModel } from 'src/models/tasktype.model';
import { EmployeeViewModel } from 'src/models/employee.model';
import { DepartmentViewModel } from 'src/models/department.model';
import { EmployeesService } from '../employees/employees.service';
import { DepartmentsService } from '../departments/departments.service';
import { PrioritiesService } from '../priorities/priorities.service';
import { PriorityViewModel } from 'src/models/priority.model';
import { TasktypesService } from '../tasktypes/tasktypes.service';
import { TaskDetailsService } from './task-details.service';
import { TaskDetailViewModel, TaskDetail } from 'src/models/task-detail.model';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss']
})
export class TasksComponent implements OnInit {
  isSuperUser;
  depts = []; users = [];
  currentTask; alltask: any = {};
  isLoading = true; dcheck;
  comment;
  filChk; levels;
  currentuser; EmpId;
  postComment = {};
  editChk; ATN; tempLvl = [];

  //New variables defined here
  registerTaskForm: FormGroup;
  registerCommentForm: FormGroup;
  myTasks: AllTaskViewModel[] = [];
  taskDetails: TaskDetailViewModel[] = [];
  employees: EmployeeViewModel[] = [];
  priorities: PriorityViewModel[] = [];
  tasktypes: TaskTypeViewModel[] = [];
  departments: DepartmentViewModel[] = [];

  _task: AllTaskViewModel = new AllTaskViewModel();
  task: AllTask = new AllTask();

  _taskDetail: TaskDetailViewModel = new TaskDetailViewModel();
  taskDetail: TaskDetail = new TaskDetail();

  constructor(
    private _tasksService: TasksService,
    private _employeesService: EmployeesService,
    private _prioritiesService: PrioritiesService,
    private _departmentsService: DepartmentsService,
    private _taskTypesService: TasktypesService,
    private _taskDetailsService: TaskDetailsService,
    private _fb: FormBuilder
  ) {
    this.registerTaskForm = this._fb.group({
      TaskCode: [''],
      CreatedBy: [''],
      AssignedToCode: ['0'],
      TaskSubject: ['', Validators.compose([
        Validators.required,
        Validators.minLength(5)])],
      TaskBody: [''],
      DateTime: [''],
      DueDate: [''],
      isActive: [],
      isReplyed: [],
      isClosed: [],
      //Foreign key
      TaskType: ['', Validators.required],
      //Foreign key 
      Priority: ['', Validators.required],
      Comment: ['']
    });

    this.registerCommentForm = this._fb.group({
      Comment: ['', Validators.compose([
        Validators.required,
        Validators.minLength(1)])],
    });
  }

  ngOnInit() {
    this.GetAllTasks();
    this.GetPriorities();
    this.GetAllEmployees();
    this.GetTaskTypes();
    this.GetAllDepartments();
    this.SetFormDefaults();
  }

  GetAllTasks() {
    this._tasksService.getAllTasks().subscribe((res: AllTaskViewModel[]) => {
      this.myTasks = res;
    });
  }

  GetAllDepartments() {
    this._departmentsService.GetDepartments().subscribe((res: DepartmentViewModel[]) => {
      this.departments = res;
    });
  }

  GetAllEmployees() {
    this._employeesService.GetEmployees().subscribe((res: EmployeeViewModel[]) => {
      this.employees = res;
    });
  }

  GetPriorities() {
    this._prioritiesService.getPriorities().subscribe((res: PriorityViewModel[]) => {
      this.priorities = res;
    });
  }

  GetTaskTypes() {
    this._taskTypesService.getTaskTypes().subscribe((res: TaskTypeViewModel[]) => {
      this.tasktypes = res;
    });
  }

  Select(task) {
    this.dcheck = true;
    this.currentTask = task;
    this._taskDetailsService.getTaskDetailById(this.currentTask.AllTaskId).subscribe((res: TaskDetailViewModel[]) => {
      this.taskDetails = res;
    });
  }

  Save() {
    debugger;
    this.SetFormValues();
    this._tasksService.addUpdateTask(this._task).subscribe(res => {

    });
  }

  SetFormValues() {
    this._task.AllTaskId = this.task.allTaskId;
    this._task.AssignedToCode = this.task.assignedToCode;
    this._task.TaskSubject = this.task.taskSubject;
    this._task.TaskBody = this.task.taskBody;    
    this._task.CreatedBy = this.task.createdBy;
    this._task.CreatedDate = new Date();
    this._task.DueDate = this.task.dueDate;
    this._task.EmployeeId = this.task.employeeId;
    this._task.DepartmentId = this.task.departmentId;
    this._task.TaskTypeId = this.task.taskTypeId;
    this._task.PriorityId = this.task.priorityId;
  }

  SetCommentFormValues() {
    this.taskDetail.allTaskId = this.currentTask.AllTaskId;
    this._taskDetail.AllTaskId = this.taskDetail.allTaskId;
    this._taskDetail.Comment = this.taskDetail.comment;
    this._taskDetail.CommentDateTime = new Date();
    this._taskDetail.EmployeeId = this.taskDetail.employeeId;
    this._taskDetail.IsReplyed = this.taskDetail.isReplyed;
    //this._taskDetail.TaskDetailId = this.taskDetail.taskDetailId;
  }

  SetFormDefaults() {
    this.task.taskTypeId = 3;
    this.task.priorityId = 3;
  }

  Reply() {
    this.SetCommentFormValues();
    this._taskDetailsService.addUpdateComment(this._taskDetail).subscribe(res => {
      alert(res);
    });
  }
}

