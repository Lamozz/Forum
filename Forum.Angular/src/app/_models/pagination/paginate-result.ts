export interface PaginateResult<T> {
    pageIndex: number;
    pageSize: number;
    totalItems: number;
    items: T[];
}