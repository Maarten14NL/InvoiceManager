import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable()
export class HttpService {

    constructor() { }

    public url: string = '';
    public data: Array<any> = [];

    returnData = {};

    // Uses http.get() to load data from a single API endpoint
    Get = function (url) {
        return this.http.get(url);
    };

    Post = function (url, data) {
        return this.http.post(url, data, httpOptions);
    };

    DownLoadFile = function (url) {
        const downloadOptions = {
            responseType: 'blob' as 'json',
            headers: new HttpHeaders({
                'Authorization': this.authKey,
            }),
        };

        return this.http.get(url, downloadOptions);
    };
}
