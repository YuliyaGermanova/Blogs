import {Component, OnInit, Output} from '@angular/core';
import {Post, PostsService} from '../shared/posts.service';
import { CreatePostModalComponent } from '../create-post-modal/create-post-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  postList: Post[] = [];

  constructor(
    private postsService: PostsService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.postsService.fetchAllPosts();
    this.postsService.getPosts().subscribe(posts => {
      this.postList = posts;
    });
  }

  createPostModal(): void {
    this.dialog.open(CreatePostModalComponent);
  }
}
