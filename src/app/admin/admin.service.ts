import { Injectable } from '@angular/core';
import { BaseApiService } from '../core/base-api.service';
import { TransportService } from '../core/transport.service';
import { Observable } from 'rxjs';

import { User, UserTask } from './user.model';

@Injectable()

export class AdminService extends BaseApiService<User> {

    constructor(transport: TransportService) {
        super(transport);
        this.name = 'users';
    }

    assignTask(userTask: UserTask): Observable<Object> {
        return this.transport.post(this.name + '/assigntask', userTask);
    }
}