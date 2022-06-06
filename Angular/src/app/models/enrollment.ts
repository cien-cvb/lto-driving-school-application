import { DeclarationListEmitMode } from "@angular/compiler";

export class Enrollment{
    enrollmentID: number;
    studID: string;
    instId: string;
    enrollmentTypeID: number;
    mvTypeID: string;
    courseID: number;
    enrollmentDate: Date;
    dlCodes: string;
    assessment: boolean;
    overallRating: boolean;
    dateStarted: Date;
    dateCompleted: Date;
    remarks: string;
    deleteFlag: boolean;
}
