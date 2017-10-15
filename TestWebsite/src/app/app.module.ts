import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
//import { VideoGameListComponent } from './video-game-list/video-game-list.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [ AppComponent],//, VideoGameListComponent ],
  imports: [
    BrowserModule,
    FormsModule,
      HttpModule,
      NgxDatatableModule
  ],
  providers: [],
  bootstrap: [AppComponent]//, VideoGameListComponent]
})
export class AppModule { }
