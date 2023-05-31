import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() buttonStyle: string;
  @Input() buttonName: string;
  @Input() disabled: boolean;

  @Output() buttonClicked: EventEmitter<void> = new EventEmitter<void>();

  handleClick(): void {
    if (!this.disabled) {
      this.buttonClicked.emit();
    }
  }

  constructor(

  ) {
  }

  
}
