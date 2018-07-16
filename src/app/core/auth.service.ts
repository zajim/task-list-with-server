import { Injectable, OnDestroy } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from "rxjs/operators";
import { BaseApiService } from '../core/base-api.service';
import { TransportService } from '../core/transport.service';
import { Login } from '../login/login.model';
import { Router } from '@angular/router';

@Injectable()

export class AuthService extends BaseApiService<Login> {

    constructor(transport: TransportService, private _router: Router) {
        super(transport);
        this.name = 'auth';
    }

    login(loginData: Login): Observable<boolean> {
        return this.transport.post(this.name, loginData).pipe(map(response => {
            const token = response['token'];
          if (token) {
            localStorage.setItem('loggedUser', JSON.stringify(response));
            localStorage.setItem('token', token);
            return true;
          }
          return false;
        }));
    }

    logout(): void {
        localStorage.clear();
        this._router.navigate(['/login']);
        location.reload();
    }

    get isLoggedIn(): boolean {
        return !!localStorage.getItem('loggedUser') && !! localStorage.getItem('token');
    }

    get Roles(): Array<string> {
        return this.transport.roles;
    }

    get Privileges(): Array<string> {
        return this.transport.privileges;
    }

    get UserId(): string {
        return this.transport.userId;
    }

    hasPrivilege(privilege: string): boolean {
        if (this.Privileges) {
            return this.Privileges.indexOf(privilege) > -1;
        }
        return false;
    }

    hasRole(role: string): boolean {
        if (this.Roles) {
            return this.Roles.indexOf(role) > -1;
        }
        return false;
    }
}