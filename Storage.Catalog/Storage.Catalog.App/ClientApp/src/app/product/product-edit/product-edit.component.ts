import { ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { BookService } from '../services/book.service';
import { CdService } from '../services/cd.service';
import { CrudService } from '../services/crud.service';
import { DvdService } from '../services/dvd.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent {

  @ViewChild('imageInput', { static: false }) private imageInputRef: ElementRef<HTMLInputElement>;

  form: FormGroup;

  isValid = false;
  showErrors = false;

  id: number;
  private readonly productService: CrudService<any>;
  productCategory: string;

  constructor(private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              bookService: BookService,
              cdService: CdService,
              dvdService: DvdService,
              private changeDetectorRef: ChangeDetectorRef) {

    this.form = this.formBuilder.group({
      artist: [null, [Validators.required]],
      synopsis: [null, [Validators.required]],
      author: [null, [Validators.required]],
      id: null,
      cover: null,
      title: [null, [Validators.required]],
      releaseDate: [null, [Validators.required]],
      image: null,
      imageName: null
    });

    this.form.controls.author.disable();
    this.form.controls.synopsis.disable();
    this.form.controls.artist.disable();

    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');
      this.productCategory = params.get('productCategory');
    });
    
    if (this.productCategory === 'books') {
      this.productService = bookService;
      this.form.controls.author.enable();
    }
    if (this.productCategory === 'cds') {
      this.productService = cdService;
      this.form.controls.artist.enable();
    }
    if (this.productCategory === 'dvds') {
      this.productService = dvdService;
      this.form.controls.synopsis.enable();
    }
    
    this.productService.getById(this.id).subscribe(product => {
      if (product !== undefined && product !== null) {
        this.form.patchValue(product);
      }
    });
  }

  processFile(files: FileList) {
    const file = files.item(0);

    if (!file) {
      return;
    }

    const reader = new FileReader();

    reader.onload = (e) => {
      this.form.patchValue({
        image: e.target.result,
        imageName: file.name
      });
      this.changeDetectorRef.markForCheck();
      this.isValid = true;
    }

    reader.readAsArrayBuffer(file);
  }

  selectImage() {
    this.imageInputRef.nativeElement.click();
  }

  save() {
    if (this.form.invalid) {
      this.showErrors = true;
      return;
    }

    this.productService.save(this.form.value).subscribe(() => this.router.navigate(['./']));
  }
}
