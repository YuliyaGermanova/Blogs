import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import {map} from 'rxjs/operators';

export interface PostType {
  id?: number;
  name: string;
}

@Injectable({providedIn: 'root'})
export class PostTypeService {

  private types: PostType[] = [];

  private typesSubject = new Subject<PostType[]>();

  constructor(private http: HttpClient) {}

  getPostsTypes(): Subject<PostType[]> {
    return this.typesSubject;
  }

  fetchAllPostTypes(): void {
    this.http.get<any>('api/blog/postType').pipe(map(data => {
      this.types = data;
    })).subscribe(() => {
      this.typesSubject.next(this.types);
    });
  }

  addPostType(type: PostType): Observable<PostType> {
    return this.http.post<any>('api/blog/postType/', type);
  }

  deletePostType(type: PostType): void {
    this.http.delete<any>(`api/blog/postType/${type.id}`).subscribe(() => {
        this.types = this.types.filter(p => p.id !== type.id);
        this.typesSubject.next(this.types);
      },
      error => console.error(error));
  }
}
