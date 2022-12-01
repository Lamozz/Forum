import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { Filter } from "./filter";

export class PaginateRequest {
    pageIndex: number;
    pageSize: number;
    columnNameForSorting: string;
    sortDirection: string;
    filter: Filter;

    constructor(matPaginator: MatPaginator, sort: MatSort, filter: Filter) {
        this.pageIndex = matPaginator.pageIndex;
        this.pageSize = matPaginator.pageSize;
        this.columnNameForSorting = sort.active;
        this.sortDirection = sort.direction;
        this.filter = filter;
    }
}