import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BaseApiService } from './base-api.service';
import { TransportService } from './transport.service';
import { AuthGuard } from './auth.guard';
import { AuthService } from './auth.service';

@NgModule({
    imports: [
        HttpClientModule
    ],
    exports: [],
    declarations: [
    ],
    providers: [
        BaseApiService,
        TransportService,
        AuthService,
        AuthGuard
    ],
})
export class CoreModule { }
