import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-student-toolkit',
  templateUrl: './student-toolkit.component.html',
  styleUrls: [
    './student-toolkit.component.scss',
    '../../admin/dashboard-admin/dashboard-admin.component.scss'
  ]
})
export class StudentToolkitComponent {
  // Display
  collapsed: boolean = false;
  displayCreateCoverLetter: boolean = false;
  // FormGroup for CV
  public formCV = new FormGroup({
    intro: new FormControl(),
    salesPitch1: new FormControl(),
    salesPitch2: new FormControl(),
    salesPitch3: new FormControl(),
    conclusion: new FormControl()
  })
  // Form validation.
  lblText: string = '';
  missingIntro: boolean = false;
  // Methods
  onClickCreateCV() {
    // Showing the popup
    this.displayCreateCoverLetter = true;
  }
  onClickClosePopup() {
    this.displayCreateCoverLetter = false;
  }
  // Cover letter creation
  submitCV() {
    // Form validation
    if (!this.validateForm()) return;
    // Creating the CV
    this.createCV();
  }
  validateForm(): boolean {
    // Clearing previous validations.
    this.clearValidation();

    // Validating form.
    let valid: boolean = true;

    if (!this.formCV.get('intro')!.value) {
      valid = false;
      this.missingIntro = true;
      if (this.lblText.length == 0)
        this.lblText = 'Missing required fields.';
    }

    return valid;
  }
  clearValidation(): void {
    this.missingIntro = false;
    this.lblText = '';
  }
  createCV() {
    // Collecting all relevant values.
    let introduction: string = this.formCV.get('intro')!.value;
    let pitch1: string = this.formCV.get('salesPitch1')!.value ?? '';
    let pitch2: string = this.formCV.get('salesPitch2')!.value ?? '';
    let pitch3: string = this.formCV.get('salesPitch3')!.value ?? '';
    let conclusion: string = this.formCV.get('conclusion')!.value ?? '';
    // Calling the API to create the cover letter.

  }
}
