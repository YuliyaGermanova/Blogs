import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import {map} from 'rxjs/operators';
import { PostType } from './posttypes.service';

export interface Post {
  id?: number;
  createDate: Date | string;
  postContent: string;
  postType: PostType;
  user: User;
}

export interface User {
  id: number;
  login: string;
}

@Injectable({providedIn: 'root'})
export class PostsService {

  private posts: Post[] = [];

  private postsSubject = new Subject<Post[]>();

  constructor(
    private http: HttpClient,
  ) {}

  getPosts(): Subject<Post[]> {
    return this.postsSubject;
  }

  fetchAllPosts(): void {
    this.http.get<any>('api/blog/post').pipe(map(data => {
      this.posts = data.map(post => ({
        id: post.id,
        createDate: new Date(post.createDate),
        postContent: post.postContent,
        postType: post.postType,
        user: post.user
      }));
    })).subscribe(() => {
      this.postsSubject.next(this.posts);
    });
  }

  savePost(post: Post): void {
    this.http.post<Post>('api/blog/post/', post).subscribe(data => {
        this.posts.push(data);
        this.postsSubject.next(this.posts);
      },
      error => console.error(error));
  }

  changePost(post: Post): void {
    const requestBody = {
      id: post.id,
      postContent: post.postContent,
      postType: post.postType,
      user: post.user,
    };
    this.http.put<Post>(`api/blog/post/${post.id}`, requestBody, {}).subscribe(data => {
        this.posts.map(p => {
          return p.id !== post.id ? p : {
            ...data,
            createDate: new Date(data.createDate).toJSON(),
          };
        });
        this.postsSubject.next(this.posts);
      },
      error => console.error(error));
  }

  deletePost(post: Post): void {
    this.http.delete<any>(`api/blog/post/${post.id}`).subscribe(() => {
      this.posts = this.posts.filter(p => p.id !== post.id);
      this.postsSubject.next(this.posts);
    },
    error => console.error(error));
  }
}
