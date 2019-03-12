import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


    getuser(uname: string): Observable<any> {
      return this.http.get('//localhost:5000/api/' + uname );
    }

    getallusers(): Observable<any> {
      return this.http.get('//localhost:5000/api/users');
    }
}
