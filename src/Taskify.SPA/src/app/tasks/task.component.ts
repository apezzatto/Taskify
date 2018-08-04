import { Component, OnInit } from '@angular/core';
import { TaskType } from '../_models/task/TaskType';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  tasksType: TaskType[];
  constructor() { }

  ngOnInit() {
  }

}
