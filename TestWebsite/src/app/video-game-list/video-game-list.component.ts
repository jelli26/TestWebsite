import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { videoGame } from './video-game'

@Component({
  selector: 'video-game-list2',
  templateUrl: './video-game-list.component.html',
  styleUrls: ['./video-game-list.component.css']
})
export class VideoGameListComponent implements OnInit {

    constructor(private _httpService: Http) { }

  public apiVideoGameListValues: videoGame[] = [];
  ngOnInit() {
      //this._httpService.get('/api/videogamelistservice').subscribe(videogamelistservice => {
      //    this.apiVideoGameListValues = videogamelistservice.json() as videoGame[];
      //});
  }

}
