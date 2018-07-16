import { Injectable, OnDestroy } from '@angular/core';
import { Task, TaskStatus, Status } from './task.model';
import { BaseApiService } from '../core/base-api.service';
import { TransportService } from '../core/transport.service';
import { Observable, BehaviorSubject, interval, Subscription } from 'rxjs';

@Injectable()

export class TasksService extends BaseApiService<Task> {

    private _tasks: Task[] = [];
    private _taskSource: BehaviorSubject<Task[]>;
    public tasksObserver: Observable<Task[]>;

    constructor(transport: TransportService) {
        super(transport);
        this.name = 'tasks';
        
        this._taskSource = new BehaviorSubject<Task[]>(this._tasks);
        this.tasksObserver = this._taskSource.asObservable();
        let count: number = 1;
    }

    get tasks(): Task[] {
        return this._tasks;
    }

    set tasks(tasks: Task[]) {
        this._tasks = tasks;
    }

    public addTask(task: Task): void {
        let createSub = this.create(task).subscribe((result: boolean) => {
            if (result) {
                this._tasks.push(task);
                this.notifyChanges();
                createSub.unsubscribe();
            }
        });
    }

    public deleteTask(task: Task): void {
        let deleteSub = this.delete(task.id).subscribe((result: boolean) => {
            if (result) {
                var index = this._tasks.indexOf(task);
                if (index > -1) {
                    this._tasks.splice(index, 1);
                    this.notifyChanges();
                    deleteSub.unsubscribe();
                }
            }
        });
    }

    public updateTask(task: Task) : void {
        let updateSub = this.update(task.id, task).subscribe((result: boolean) => {
            if (result) {
                this.notifyChanges();
                updateSub.unsubscribe();
            }
        });
    }

    public onTaskChanged(): void {
        this.notifyChanges();
    }

    get Statuses(): Status[] {
        let statuses: Status[] = [];
        for (let item in TaskStatus) {
            if (!isNaN(Number(item))) {
                let status = new Status();
                status.value = Number(item);
                status.name = TaskStatus[item];
                statuses.push(status);
            }
        }
        return statuses;
    }

    public checkTitleNotTaken(title: string): boolean {
        if (!title) {
            return false;
        }
        let tasks = this._tasks.filter((item: Task) => item.title.toLowerCase() === title.toLowerCase());
        return tasks && tasks.length > 0;
      }

    private notifyChanges(): void {
        this._taskSource.next(this._tasks);
    }
}