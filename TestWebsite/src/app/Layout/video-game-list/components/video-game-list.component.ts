import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { videoGame } from '../models';
import { gameListService} from '../services';

@Component({
  selector: 'video-game-list',
  templateUrl: './video-game-list.component.html',
  styleUrls: ['./video-game-list.component.css']
})
export class VideoGameListComponent implements OnInit {

    constructor(private gamelistService: gameListService) { }

  public apiVideoGameListValues: videoGame[] = [];
  ngOnInit()
  {
    this.gamelistService.getGameList()
                        .subscribe(data =>
                        {
                          this.apiVideoGameListValues = data;
                        });
  }

}
