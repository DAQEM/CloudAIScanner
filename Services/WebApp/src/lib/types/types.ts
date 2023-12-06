interface AISystem {
	guid?: string;
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
	files?: File[];
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
	aiSystemDtos?: AISystem[];
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

interface OpenAiModel {
	id: string;
	object: string;
	created: number;
	owned_by: string;
}

interface Account {
	id: string;
	access_token: string;
}

interface File {
	guid?: string;
	filepath?: string;
	filetype?: string;
}

export type {
	AISystem,
	AISystemStatus,
	Account,
	ApprovalStatus,
	Certificate,
	FetchError,
	File,
	MemberStates,
	OpenAiModel,
	Pagination,
	Provider,
	ScanCertificate
};
