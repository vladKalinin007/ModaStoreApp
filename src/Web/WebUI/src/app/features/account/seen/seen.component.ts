import {Component, OnInit} from '@angular/core';
import {HistoryService} from "../../../shared/services/history.service";
import {Observable} from "rxjs";
import {ISeenProductList} from "../../../core/models/customer/seenProductList";

@Component({
  selector: 'app-seen',
  templateUrl: './seen.component.html',
  styleUrls: ['./seen.component.scss']
})
export class SeenComponent implements OnInit {

    history$: Observable<ISeenProductList>

    constructor(private historyService: HistoryService) {

    }

    ngOnInit(): void {
      this.history$ = this.historyService.history$;
    }

}
