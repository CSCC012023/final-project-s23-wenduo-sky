import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class APIService {
  constructor(private hc: HttpClient) { }

  public get(url: string, options?: any) {
    return this.hc.get(url, options);
  }

  public post(url: string, data: any, options?: any) {
    return this.hc.post(url, data, options);
  }
}
