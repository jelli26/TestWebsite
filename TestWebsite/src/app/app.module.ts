import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { LayoutModule } from './Layout/layout.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { VideoGameListComponent } from './Layout/video-game-list/components/video-game-list.component';
import { PageNotFoundComponent } from './Layout/page-not-found/components/page-not-found.component';
import { AngularTestComponent } from './Layout/angular-test/components/angular-test.component';

const appRoutes: Routes =
[
  { path: 'angular-test', component: AngularTestComponent },
  { path: 'game-list',    component: VideoGameListComponent },
  { path: '',
    redirectTo: '/angular-test',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  declarations: [ AppComponent],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NgxDatatableModule,
    LayoutModule,
    RouterModule.forRoot( appRoutes, { enableTracing: false } )
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
