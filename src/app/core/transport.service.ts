import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';


@Injectable()
export class TransportService {

    protected baseUrl: string;
    
    constructor(
        private _http: HttpClient
    ) {
        this.baseUrl = environment.API_URL;
    }

    get baseApiUrl() {
        return this.baseUrl;
    }

    get(resource, queryData?: HttpParams, fullResponse: boolean = false): Observable<any> {
        return this._http.get(this.baseUrl + resource, <any>{
            headers: this.headers,
            params: queryData,
            observe: fullResponse ? 'response' : 'body'
        });
    }

    post(resource, body?, queryData?: HttpParams) {
        return this._http.post(this.baseUrl + resource, body, { headers: this.headers, params: queryData });
    }

    put(resource, body, queryData?: HttpParams) {
        return this._http.put(this.baseUrl + resource, body, { headers: this.headers, params: queryData });
    }

    delete(resource) {
        return this._http.delete(this.baseUrl + resource, { headers: this.headers });
    }

    deleteImage(resource, fullResponse: boolean = false) {
        return this._http.delete(this.baseUrl + resource, <any>{
            headers: this.headers,
            observe: fullResponse ? 'response' : 'body'
        });
    }

    raw(method, resource, data): Observable<any> {
        const request = new HttpRequest(method, this.baseUrl + resource, data, { headers: this.headers.delete('Content-Type') });
        return this._http.request(request);
    }

    uploadSingle(method, resource, fileParam: string, file: File, postData?: HttpParams) {
        const formData: FormData = new FormData();
        formData.append(fileParam, file, file.name);
        return this._http[method](this.baseUrl + resource, formData, { headers: this.headers.delete('Content-Type'), params: postData });
    }

    get token(): any {
        const currentUser = JSON.parse(localStorage.getItem('loggedUser'));
        if (currentUser) {
            return currentUser['token'];
        }
    }

    get tokenExpires(): any {
        const currentUser = JSON.parse(localStorage.getItem('loggedUser'));
        if (currentUser) {
            return currentUser['TokenExpire'];
        }
    }

    get privileges(): any {
        const currentUser = JSON.parse(localStorage.getItem('loggedUser'));
        if (currentUser) {
            return currentUser['privileges'];
        }
    }

    get roles(): Array<string> {
        let userData = JSON.parse(localStorage.getItem('loggedUser'));
        if (userData) {
            return userData['roles'];
        }
    }

    get userId(): string {
        let userData = JSON.parse(localStorage.getItem('loggedUser'));
        if (userData) {
            return userData['userId'];
        }
    }

    get headers(): HttpHeaders {
        let headers = new HttpHeaders({
            'Content-Type': 'application/json'
        });
        if (this.token) {
            headers = headers.append('Authorization', 'Bearer ' + this.token);
        }
        if (this.userId) {
            headers = headers.append('UserId', this.userId);
        }
        return headers;
    }
}