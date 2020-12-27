import { RangeFilter } from "./RangeFilter";

export interface BookFilter {
    priceRangeFilter: RangeFilter;
    titleFilter:      string;
    authorFilter:     string;
    haveImages:       boolean;
}
