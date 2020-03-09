import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) { }

    public url: string = '';
    public data: Array<any> = [];

    returnData = {};

    // Uses http.get() to load data from a single API endpoint
    Get = function (url) {
        return this.http.get(url)
    }

    Post = function (url, data) {
        return this.http.post(url, data, httpOptions)
    }

    DownLoadFile = function (url) {
        const httpOptions = {
            responseType: 'blob' as 'json',
            headers: new HttpHeaders({
                'Authorization': this.authKey,
            })
        };

        return this.http.get(url, httpOptions);
    }
}
