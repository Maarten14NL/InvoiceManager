import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

// const httpOptions = {
//     headers: new HttpHeaders({
//         'Content-Type': 'application/json; charset=utf-8',
//     }),
// };

@Injectable()
export class HttpService {

    // constructor(private _http: HttpClient) { }

    public url: string = '';
    public data: Array<any> = [];
    returnData = {};

    // Uses http.get() to load data from a single API endpoint
    Get = function (url) {
        return this._http.get(url);
    };

    Post = function (url, data) {

        const body = new FormData();
        body.append('data', JSON.stringify(data));


        return this.HttpClient.post(url, body);
    };

    DownLoadFile = function (url) {
        const downloadOptions = {
            responseType: 'blob' as 'json',
            headers: new HttpHeaders({
                'Authorization': this.authKey,
            }),
        };

        return this.HttpClient.get(url, downloadOptions);
    };
}
