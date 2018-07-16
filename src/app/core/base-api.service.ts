import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, catchError, throwIfEmpty } from "rxjs/operators";

import { TransportService } from './transport.service';
import { HttpResponse } from '@angular/common/http';

@Injectable()
export class BaseApiService<T> {
    name: string;

    constructor(
        public transport: TransportService
    ) { }

    getAll(condition: any = {}): Observable<T[]> {
        return this.transport.get(this.name, condition)
        .pipe(map(response => <T[]>response));
    }

    getById(id: string, condition: any = {}): Observable<T> {
        return this.transport.get(this.name + '/' + id, condition)
            .pipe(map(response => <T>response));
    }

    get(): Observable<T> {
        return this.transport.get(this.name)
            .pipe(map(response => <T>response));
    }

    create(item: T): Observable<Object> {
        return this.transport.post(this.name, item);
    }

    update(id: string, item: T) {
        if (id != null) {
            return this.transport.put(this.name + '?id=' + id, item);
        } else {
            return this.transport.put(this.name, item);
        }
    }

    updateForRoute(resource: string, item: T) {
        return this.transport.put(resource, item);
    }

    delete(id: string): Observable<Object> {
        return this.transport.delete(this.name + '?id=' + id);
    }
}
