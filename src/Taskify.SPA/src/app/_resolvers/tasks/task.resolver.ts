import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { TaskType } from '../../_models/task/TaskType';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AlertifyService } from '../../_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { UserService } from '../../_services/user.service';

@Injectable()
export class TaskResolver implements Resolve<TaskType[]> {
    pageSize = 5;
    pageNumber = 1;
    likesParams = 'Likers';

    constructor(private taskService: TaskService,
        private router: Router,
        private alertify: AlertifyService) {}

        resolve(route: ActivatedRouteSnapshot): Observable<TaskType[]> {
            return this.taskService.getUsers(this.pageNumber, this.pageSize, null, this.likesParams)
            .pipe(
                catchError(error => {
                    this.alertify.error('Problem retrieving data');
                    this.router.navigate(['/home']);
                    return of(null);
                })
            );
        }
}
