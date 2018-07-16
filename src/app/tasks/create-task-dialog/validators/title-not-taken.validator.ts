import { AbstractControl, ValidatorFn } from '@angular/forms';
import { TasksService } from '../../tasks.service';

export class ValidateTitleNotTaken {
  static createValidator(tasksService: TasksService): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const forbidden = tasksService.checkTitleNotTaken(control.value);
      return forbidden ? {'uniqueTitle': {value: control.value}} : null;
    };
  }
}