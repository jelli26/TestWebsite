import { Injectable } from '@angular/core';
// import { Http } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { videoGame } from '../models/video-game';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

@Injectable()
export class gameListService
{
  private gameListURL = '/api/videogamelistservice';

  constructor(private _httpService: HttpClient) {}

  public getGameList(): Observable<videoGame[]>
  {
    // return  this._httpService.get(this.gameListPath)
    //                          .subscribe(data =>
    //                          {
    //                          return data.json() as videoGame[];
    //                          });

    return this._httpService.get<videoGame[]>(this.gameListURL);
  }
}
