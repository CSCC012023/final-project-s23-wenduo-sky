import { Component, inject } from '@angular/core';
import { Database, ref, set } from '@angular/fire/database';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'yourscope';

  private database: Database = inject(Database);

  constructor(private hc: HttpClient) { }

  addFireData() {
    const test = ref(this.database, '/test')
    const d = new Date();
    let time = d.getTime();
    set(test, {
      currTime: time
    });
  }

  addSQLData() {
    const body = { Title: "Tested", Description: "Tested" };
    this.hc.post('https://localhost:7184/api/Test/v1/add-to-database', body).subscribe(res => {
      console.log(res);
    });
  }
}
