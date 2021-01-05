export interface PropertyDetails {
    UnitNumber: number,
    HouseNumber: number,
    StreetName: string,
    Locality: string,
    PostCode: number
}

export interface SaleRecord {
    Settlement: Date,
    Price: number
}
