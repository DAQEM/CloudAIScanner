export type System = {
	id: string;
	name: string;
	provider: string;
	date: string;
	status: string;
};

export const systems: System[] = [
	{
		id: '876364',
		name: 'AI System 1',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Approved'
	},
	{
		id: '876365',
		name: 'AI System 2',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending'
	},
	{
		id: '876366',
		name: 'AI System 3',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending'
	},
	{
		id: '876367',
		name: 'AI System 4',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Approved'
	},
	{
		id: '876368',
		name: 'AI System 5',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending'
	}
];

export const getSystem = async (id: string): Promise<System | undefined> => {
	const response = await fetch(`http://localhost:5050/api/system/${id}`);

	if (response.ok) {
		const system: System = await response.json();
		return system;
	}

	return undefined;
};

export const getSystems = async (): Promise<System[]> => {
	const response = await fetch(`http://localhost:5050/api/system`);

	if (response.ok) {
		const systems: System[] = await response.json();
		return systems;
	}

	return [];
};
