import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { throwError } from 'rxjs';
import { BookService } from '../services/book.service';
import { CdService } from '../services/cd.service';
import { DvdService } from '../services/dvd.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {

  @ViewChild('imageInput', { static: false }) private imageInputRef: ElementRef<HTMLInputElement>;

  bookForm: FormGroup;
  cdForm: FormGroup;
  dvdForm: FormGroup;

  isBook = false;
  isCd = false;
  isDvd = false;
  isValid = false;

  file: any;
  id: number;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService,
    private cdService: CdService,
    private dvdService: DvdService,
    private cd: ChangeDetectorRef) {

    this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');

      if (this.router.url == `/book/${this.id}/edit` || this.router.url == '/book/new') {
        this.isBook = true;
        this.isCd = false;
        this.isDvd = false;
        this.buildBookForm(this.id);
      }
      if (this.router.url == `/cd/${this.id}/edit` || this.router.url == '/cd/new') {
        this.isCd = true;
        this.isDvd = false;
        this.isBook = false;
        this.buildCdForm(this.id);
      }
      if (this.router.url == `/dvd/${this.id}/edit` || this.router.url == '/dvd/new') {
        this.isDvd = true;
        this.isCd = false;
        this.isBook = false;
        this.buildDvdForm(this.id);
      }
    });

    if (this.isBook) {
      bookService.getById(this.id).subscribe(book => {
        if (book !== undefined && book !== null) {
          this.bookForm.patchValue(book);
        }
      });
    }

    if (this.isCd) {
      cdService.getById(this.id).subscribe(cd => {
        if (cd !== undefined && cd !== null) {
          this.cdForm.patchValue(cd);
        }
      });
    }

    if (this.isDvd) {
      dvdService.getById(this.id).subscribe(dvd => {
        if (dvd !== undefined && dvd !== null) {
          this.dvdForm.patchValue(dvd);
        }
      });
    }
  }

  ngOnInit(): void {
  }

  buildBookForm(id: number) {
    this.bookForm = this.formBuilder.group({
      author: [null, [Validators.required]],
      id,
      cover: null,
      title: [null, [Validators.required]],
      releaseDate: null,
      image: null,
      imageName: null
    });
  }

  buildCdForm(id: number) {
    this.cdForm = this.formBuilder.group({
      artist: [null, [Validators.required]],
      id,
      cover: null,
      title: [null, [Validators.required]],
      releaseDate: null,
      image: null,
      imageName: null
    });
  }

  buildDvdForm(id: number) {
    this.dvdForm = this.formBuilder.group({
      synopsis: [null, [Validators.required]],
      id,
      cover: null,
      title: [null, [Validators.required]],
      releaseDate: null,
      image: null,
      imageName: null
    });

  }


  processFile(files: FileList) {
    const file = files.item(0);

    if (!file) {
      return;
    }

    const reader = new FileReader();

    reader.onload = (e) => {
      if (this.isBook) {
        debugger;
        this.bookForm.patchValue({
          image: e.target.result,
          imageName: file.name
        });
      }

      if (this.isCd) {
        this.cdForm.patchValue({
          image: e.target.result,
          imageName: file.name
        });
      }

      if (this.isDvd) {
        this.dvdForm.patchValue({
          image: e.target.result,
          imageName: file.name
        });
      }

      // need to run CD since file load runs outside of zone
      this.cd.markForCheck();
      this.isValid = true;
    }

    reader.readAsArrayBuffer(file);
  }


  selectImage() {
    this.imageInputRef.nativeElement.click();
  }

  handlingData() {

    if (this.isBook) {
      this.bookForm.patchValue({
        releaseDate: new Date(this.bookForm.controls['releaseDate'].value)
      });
    }

  }

  save() {
    this.handlingData();

    if (this.isBook) {
      if ((this.bookForm.controls.title.invalid && (this.bookForm.controls.title.dirty || this.bookForm.controls.title.touched))
      || (this.bookForm.controls.author.invalid && (this.bookForm.controls.author.dirty || this.bookForm.controls.author.touched))) {
        return;
      }
      this.bookService.save(this.bookForm.value).subscribe(() => this.router.navigate(['./']));
    }

    if (this.isCd) {
      if (this.cdForm.controls.title.invalid && (this.cdForm.controls.title.dirty || this.cdForm.controls.title.touched)
      ||(this.cdForm.controls.artist.invalid && (this.cdForm.controls.artist.dirty || this.cdForm.controls.artist.touched))) {
        return;
      }
      this.cdService.save(this.cdForm.value).subscribe(() => this.router.navigate(['./']));
    }

    if (this.isDvd) {
      if (this.dvdForm.controls.title.invalid && (this.dvdForm.controls.title.dirty || this.dvdForm.controls.title.touched)
      || this.dvdForm.controls.synopsis.invalid && (this.dvdForm.controls.synopsis.dirty || this.dvdForm.controls.synopsis.touched)) {
        return;
      }
      this.dvdService.save(this.dvdForm.value).subscribe(() => this.router.navigate(['./']));
    }

  }
}
