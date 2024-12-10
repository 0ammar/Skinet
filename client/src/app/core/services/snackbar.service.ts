import { inject, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  private snackbar = inject(MatSnackBar);

  error(mseeage: string){
    this.snackbar.open(mseeage, 'Close', {
      duration: 5000,
      panelClass: ['snack-error']
    })
  }
  success(mseeage: string){
    this.snackbar.open(mseeage, 'Close', {
      duration: 5000,
      panelClass: ['snack-success']
    })
  }
}
