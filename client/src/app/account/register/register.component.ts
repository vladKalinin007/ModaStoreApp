import {Component, OnInit} from '@angular/core';
import {AsyncValidatorFn, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../account.service";
import {Router} from "@angular/router";
import {of, switchMap, timer} from "rxjs";
import {map} from "rxjs/operators";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  errors: string[] = [];
  registerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(): void {
    this.registerForm = this.fb.group({
      displayName: ['', [Validators.required]],
      email: ['',
        [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
        [this.validateEmailNottaken()]],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]]
    })
  }

  onSubmit(): void {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => {
        this.router.navigateByUrl('/shop');
      },
      error: (error) => {
        console.log(error);
        this.errors = error.errors;
      }
    })
  }

  validateEmailNottaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? {emailExists: true} : null;
            })
          )
        }
      ))
    }
  }

}
