import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { PaginatedResult } from '../../_models/Pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TaskType } from '../../_models/task/TaskType';

@Injectable()
export class TaskService {
  baseUrl = environment.apiUrl;
constructor(private authHttp: HttpClient) { }

getTaskTypes() {
  return this.authHttp
            .get<TaskType[]>(this.baseUrl + 'helper/TaskTypes/List', { observe: 'response'})
              .pipe(
                map(response => {
                  return response.body;
                })
              );
}

}
