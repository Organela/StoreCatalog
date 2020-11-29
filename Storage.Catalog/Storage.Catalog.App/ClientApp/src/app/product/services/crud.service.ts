import { Observable } from 'rxjs';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';

export class CrudService<T extends any> {
    //getById(id: any): Observable<T>;

    constructor(private http: HttpClient, protected path: string) { }

    private static createRequest(url: string, method: string, data: FormData, responseType: 'arraybuffer' | 'blob' | 'json' | 'text' = 'json') {
        return new HttpRequest(method, url, data, {
            reportProgress: true,
            responseType
        });
    }

    private getProductFormData(product: any): FormData {

        product = { ...product };
        let productJson: string;

        const formData: FormData = new FormData();

        if (!product.id) {
            delete product.id;
        }
        

        const fileData = product.image;

        const x = new Blob([fileData], {type: product.type});

        if (fileData) {
            formData.append('0', x);
        }

        // product.image = null;

        delete product.image;
        delete product.imageName;

        productJson = JSON.stringify(product);
        formData.append('productData', productJson);

        return formData;
    }

    getById(id: number): Observable<T> {
        return this.http.get<T>(`api/${this.path}/${id}`);
    }

    getAll(): Observable<T[]> {
        return this.http.get<T[]>(`api/${this.path}`);
    }

    save(product: any): Observable<HttpEvent<any>> {
        if (product.id) {
            return this.update(product);
        }
        return this.create(product);
    }

    update(product: any): Observable<HttpEvent<any>> {
        debugger;
        return this.request(CrudService.createRequest(`api/${this.path}/${product.id}`, 'PUT', this.getProductFormData(product)));
    }

    create(product: any): Observable<HttpEvent<any>> {
        return this.request(CrudService.createRequest(`api/${this.path}`, 'POST', this.getProductFormData(product)));
    }

    delete(product: any): Observable<T> {
        return this.http.delete<T>(`api/${this.path}/${product.id}`);
    }

    request(req: HttpRequest<any>): Observable<HttpEvent<any>> {
        return this.http
            .request(req);
    }
}