import { Component, OnInit } from '@angular/core';
import { AuthService } from './../core/auth.service';
import { Observable } from 'rxjs';

import { Privilege, Role } from '../core/auth.model';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  isLoggedIn: boolean;

  constructor(public authService: AuthService) {
    
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn;
  }

  onLogout(){
    this.authService.logout();
  }

}
