import { Component, OnInit } from '@angular/core';
import { TaskType } from '../_models/task/TaskType';
import { TaskService } from '../_services/tasks/task.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  taskTypes: TaskType[];
  constructor(taskService: TaskService,
    private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.taskTypes = data['tasksType'];
    });
  }

}
