export type Status = 'Approved' | 'Pending';

export const status: Status[] = ['Approved', 'Pending'];

export const getStatus = async (): Promise<Status[]> => {
	const response = await fetch(`http://localhost:5050/api/status`);

	if (response?.ok) {
		const statusList: Status[] = await response.json();
		return statusList;
	}

	return [];
};
