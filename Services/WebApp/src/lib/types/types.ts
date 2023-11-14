interface AISystem {
    guid?: string;
    name?: string;
    status?: AISystemStatus;
    url?: string;
    description?: string;
    technicalDocumentationLink?: string;
    approvalStatus?: ApprovalStatus;
    dateAdded?: string;
    provider?: Provider;
    certificate?: Certificate;
    memberStates?: MemberStates;
}

interface AISystemStatus {
    id?: string;
    status?: string;
}

interface ApprovalStatus {
    id?: string;
    status?: string;
}

interface Provider {
    guid?: string;
    name?: string;
    address?: string;
    email?: string;
    phoneNumber?: string;
    aiSystems?: AISystem[];
};

interface Certificate {
    guid?: string;
    type?: string;
    number?: number;
    expiryDate?: string;
    nameNotifiedBody?: string;
    idNotifiedBody?: number;
    scanCertificate?: ScanCertificate;
};

interface ScanCertificate {
    guid?: string;
    filename?: string;
    filepath?: string;
};

interface MemberStates {
    id?: string;
    names?: string;
};

interface FetchError {
    error: string;
};

export type { AISystem, AISystemStatus, ApprovalStatus, Provider, Certificate, ScanCertificate, MemberStates, FetchError };