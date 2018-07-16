export class Task {
    id: string;
    title: string;
    description: string;
    status: TaskStatus;
}

export enum TaskStatus {
    New = 1,
    Pending = 2,
    Done = 3
}

export class Status {
    value: number;
    name: string;
}