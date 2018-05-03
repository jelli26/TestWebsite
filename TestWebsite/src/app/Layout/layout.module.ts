import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { VideoGameListComponent } from './video-game-list/components/video-game-list.component';
import { PageNotFoundComponent } from './page-not-found/components/page-not-found.component';
import { AngularTestComponent } from './angular-test/components/angular-test.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [ VideoGameListComponent,
                  PageNotFoundComponent,
                  AngularTestComponent ],
  imports: [ BrowserModule,
             FormsModule,
             HttpModule,
             NgxDatatableModule
  ],
  providers: [],
  bootstrap: [ VideoGameListComponent,
               PageNotFoundComponent,
               AngularTestComponent]
})
export class LayoutModule { }
