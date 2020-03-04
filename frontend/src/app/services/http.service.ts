import {Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
// const httpOptions = {
//     headers: new HttpHeaders({ 'Content-Type': 'application/json' })
// };
 
@Injectable()
export class HttpService {
 
    constructor(private http:HttpClient) {}
    
    public url: string = '';
    public data: Array<any> = [];

    private returnData;
    // Uses http.get() to load data from a single API endpoint
    get() {
        return this.http.get(this.url).subscribe(
            data => { this.returnData = data;},
            err => console.error(err),
            () => console.error( this.returnData )
        );
    }

    callComplete(){
        return this.returnData;
    }
}