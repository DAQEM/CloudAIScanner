interface AISystem {
	id?: string;
	unambiguousReference?: string;
	name?: string;
	status?: AISystemStatus;
	url?: string;
	description?: string;
	technicalDocumentationLink?: string;
	approvalStatus?: ApprovalStatus;
	dateAdded?: string;
	provider?: Provider;
	certificate?: Certificate;
	memberState?: MemberStates;
}

interface AISystemStatus {
	id?: number;
	name?: string;
}

interface ApprovalStatus {
	id?: number;
	name?: string;
}

interface Provider {
	guid?: string;
	name?: string;
	address?: string;
	email?: string;
	phoneNumber?: string;
	authorizedRepresentitives: AuthorizedRepresentitive[];
}

interface Certificate {
	guid?: string;
	type?: string;
	number?: number;
	expiryDate?: string;
	nameNotifiedBody?: string;
	idNotifiedBody?: number;
	scanCertificate?: ScanCertificate;
}

interface ScanCertificate {
	guid?: string;
	filename?: string;
	filepath?: string;
}

interface MemberStates {
	id?: number;
	name?: string;
}

interface AuthorizedRepresentitive {
	guid?: string;
	name?: string;
	email?: string;
	phoneNumber?: string;
}

interface FetchError {
	error: string;
}

interface Pagination<T> {
    data: T;
	page: number;
	pageSize: number;
	totalPages: number;
}

export type {
	AISystem,
	AISystemStatus,
	ApprovalStatus,
	Certificate,
	FetchError,
	MemberStates,
	Provider,
	ScanCertificate,
    Pagination
};
